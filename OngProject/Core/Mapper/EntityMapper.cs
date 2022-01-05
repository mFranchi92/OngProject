using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using OngProject.Core.DTOs;
using OngProject.Core.Entities;
using OngProject.Core.Interfaces.IRepositories;

namespace OngProject.Core.Mapper
{
    public class EntityMapper
    {
        public CommentDto FromCommentToCommentDto(Comment comment)
        {
            var commentDto = new CommentDto() { Id = comment.Id, Body = comment.Body, CreatedAt = comment.CreatedAt };
            return commentDto;
        }

        public IEnumerable<CommentDto> FromCommentListToCommentDtoList(IEnumerable<Comment> comments)
        {
            return comments.Select(comment => new CommentDto()
            { Id = comment.Id, Body = comment.Body, CreatedAt = comment.CreatedAt });
        }
        public IEnumerable<CategoryDto> FromCategoryListCategoryDtoList(IEnumerable<Category> categories)
        {
            return categories.Select(category => new CategoryDto()
            { Id = category.Id, Name = category.Name });
        }


        public SlideDto FromSlideToSlideDto(Slide slide)
        {
            if (slide == null)
                return null;

            return new SlideDto
            {
                Id = slide.Id,
                ImageUrl = slide.ImageUrl,
                Order = slide.Order
            };
        }

        public OrganizationDto FromOrganizationToOrganizationDto(Organization organization)
        {
            if (organization == null)
                return null;

            return new OrganizationDto
            {
                Name = organization.Name,
              //  Image = organization.Image,
                Address = organization.Address,
                Phone = organization.Phone,
                FacebookUrl = organization.FacebookUrl,
                InstagramUrl = organization.InstagramUrl,
                LinkedInUrl = organization.LinkedInUrl,
            };
        }

        public Category FromCategoryUpdateDtoToCategory(CategoryUpdateDto categoryUpdateDto)
        {
            if (categoryUpdateDto == null)
            {
                return null;
            }

            return new Category
            {
                Description = categoryUpdateDto.Description,
                Image = "category_" + categoryUpdateDto.Name,
                Name = categoryUpdateDto.Name,
            };
        }

        public UserDto FromUserToUserDto(User user)
        {
            if (user == null)
            {
                return null;
            }

            return new UserDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Photo = user.Photo
            };
        }

        public Category FromCategoryCreateDtoToCategory(CategoryCreateDto categoryCreateDto)
        {
            if (categoryCreateDto == null)
            {
                return null;
            }

            return new Category
            {
                Description = categoryCreateDto.Description,
                Image = "category_" + categoryCreateDto.Name,
                Name = categoryCreateDto.Name,
            };
        }

        public Member FromMemberDtoToMember(MemberDto memberDto)
        {
            if (memberDto == null)
            {
                return null;
            }

            return new Member
            {
                Name = memberDto.Name,
                FacebookUrl = memberDto.FacebookUrl,
                InstagramUrl = memberDto.InstagramUrl,
                LinkedinUrl = memberDto.LinkedinUrl,
                Description = memberDto.Description
            };
        }
        public Testimonial FromTestimonialDtoToTestimonial(TestimonialDto testimonialDto)
        {
            if (testimonialDto == null)
            {
                return null;
            }

            return new Testimonial
            {
                Name = testimonialDto.Name,
                Content = testimonialDto.Content
            };

        }

        public Contact FromContactDtoToContact(ContactDto contactDto)
        {
            if (contactDto == null)
                return null;

            return new Contact
            {
                Name = contactDto.Name,
                Email = contactDto.Email,
                Phone = contactDto.Phone,
                Message = contactDto.Message
            };
        }

        public News FromNewsDtoToNews(NewsDto newsDto)

        {

            if (newsDto == null)

            {
                return null;
            }

            return new News

            {
                Name = newsDto.Name,
                Image = "news_" + newsDto.Name,
                Content = newsDto.Content,
                CategoryId = newsDto.CategoryId
            };
        }

        public Slide FromSlideCreateDtoToSlide(SlideCreateDto slideCreateDto)
        {
            if (slideCreateDto == null)
                return null;

            return new Slide
            {
                Text = slideCreateDto.Text,
                ImageUrl = slideCreateDto.ImageBase64,
                Order = (int)slideCreateDto.Order,
                OrganizationId = slideCreateDto.OrganizationId
            };
        }
    }
}