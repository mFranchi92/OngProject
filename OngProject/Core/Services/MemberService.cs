using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OngProject.Core.DTOs;
using OngProject.Core.Entities;
using OngProject.Core.Helper;
using OngProject.Core.Helper.Pagination;
using OngProject.Core.Interfaces.IServices;
using OngProject.Core.Interfaces.IServices.IGetUri;
using OngProject.Core.Interfaces.IUnitOfWork;
using OngProject.Core.Mapper;
using OngProject.Core.Services.GetUri;

namespace OngProject.Core.Services
{
    public class MemberService : IMemberService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUriService _uriService;

        public MemberService(IUnitOfWork unitOfWork, IUriService uriService)
        {
            _unitOfWork = unitOfWork;
            _uriService = uriService;
        }

        public async Task<ResponsePagination<GenericPagination<Member>>> GetMembers(int page, int pageSize, string controller)
        {
            //get all members
            var member = await _unitOfWork.MemberRepository.GetAll();

            //Set default values
            page = page == 0 ? 1 : page;
            pageSize = pageSize == 0 ? 10 : pageSize; 

            //get routes
            var NextRoute = $"{controller}/?page={(page+1)}";
            var PreviosRoute = $"{controller}/?page={(page-1)}";


            //get a page(entity, NumberPage, PageSize)
            var pageMembers = GenericPagination<Member>.Create(member, page, pageSize);

            //response with necessary information 
            var result = new ResponsePagination<GenericPagination<Member>>(pageMembers)
            {
                TotalRecords = pageMembers.TotalRecords,
                PageSize = pageMembers.PageSize,
                CurrentPage = pageMembers.CurrentPage,
                TotalPages = pageMembers.TotalPages,
                HasNextPage = pageMembers.HasNextPage,
                HasPreviousPage = pageMembers.HasPreviousPage,
            };

            //setUrls
            if(result.HasNextPage)
            result.NextPageUrl = _uriService.GetPaginationUri(page, NextRoute).ToString();
            if(result.HasPreviousPage)
            result.PreviousPageUrl = _uriService.GetPaginationUri(page, PreviosRoute).ToString();

            return result;
        }

        public async Task<Member> GetMember(int id)
        {
            return await _unitOfWork.MemberRepository.GetById(id);
        }

        public async Task InsertMember(MemberDto memberDto)
        {
            try
            {
                var map = new EntityMapper();
                var member = map.FromMemberDtoToMember(memberDto);
                if (memberDto.Image != null)
                { 
                    if (ValidateFiles.ValidateImage(memberDto.Image))
                    {
                        var s3helper = new S3AwsHelper();
                        string key = DateTime.Now.ToString();
                        key = key.Replace(":", "").Replace("/", "").Replace(" ", "");

                        var result = await s3helper.AwsUploadFile("member_"+key, memberDto.Image);
                        if (result.Code == 200)
                        {
                            member.Image = result.Url;
                            await _unitOfWork.MemberRepository.Insert(member);
                            await _unitOfWork.SaveChangesAsync();
                        }
                        else
                            throw new Exception(result.Errors); 
                    }
                    else
                        throw new Exception("File not valid");
                }
                else
                {
                    await _unitOfWork.MemberRepository.Insert(member);
                    await _unitOfWork.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<bool> UpdateMember(int id, MemberEditDto memberDto)
        {
            try
            {
                if (_unitOfWork.MemberRepository.EntityExists(id))
                {
                    var member = await _unitOfWork.MemberRepository.GetById(id);
                        member.Name = memberDto.Name;
                        member.LinkedinUrl = memberDto.LinkedinUrl;
                        member.InstagramUrl = memberDto.InstagramUrl;
                        member.FacebookUrl = memberDto.FacebookUrl;
                        member.Description = memberDto.Description;

                    if (memberDto.Image != null)
                    {
                        if (ValidateFiles.ValidateImage(memberDto.Image))
                        { 
                        var s3helper = new S3AwsHelper();
                        var result = await s3helper.AwsUploadFile(member.Image.Substring(member.Image.IndexOf("member_")), memberDto.Image);
                            if (result.Code == 200)
                            {
                                await _unitOfWork.MemberRepository.Update(member);
                                await _unitOfWork.SaveChangesAsync();
                                return true;
                            }
                            else
                            throw new Exception(result.Errors);
                        }
                        else
                        throw new Exception("Image not valid");
                    }
                    else
                    {
                        await _unitOfWork.MemberRepository.Update(member);
                        await _unitOfWork.SaveChangesAsync();
                        return true;
                    }
                }
                return false;
            }
            catch (Exception e)
            {

                throw new Exception (e.Message);
            }
        }

        public async Task<bool> DeleteMember(int id)
        {
            await _unitOfWork.MemberRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
        public bool EntityExists(int id)
        {
            return _unitOfWork.MemberRepository.EntityExists(id);
        }
    }
}