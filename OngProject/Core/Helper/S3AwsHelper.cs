using Amazon;
using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;
using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace OngProject.Core.Helper
{
    public class S3AwsHelper
    {
        private readonly IAmazonS3 _amazonS3;
        public S3AwsHelper()
        {
            var chain = new CredentialProfileStoreChain("app_data\\credentials.ini");
            AWSCredentials awsCredentials;
            RegionEndpoint sAEast1 = RegionEndpoint.SAEast1;
            if (chain.TryGetAWSCredentials("default", out awsCredentials))
            {
                _amazonS3 = new AmazonS3Client(awsCredentials.GetCredentials().AccessKey, awsCredentials.GetCredentials().SecretKey, sAEast1);
            }
        }
        public async Task<AwsManagerResponse> AwsUploadFile(string key, IFormFile file)
        {
            try
            {
                var putRequest = new PutObjectRequest()
                {
                    BucketName = "alkemy-ong",
                    Key = key,
                    InputStream = file.OpenReadStream(),
                    ContentType = file.ContentType
                };
                var result = await _amazonS3.PutObjectAsync(putRequest);
                var response = new AwsManagerResponse
                {
                    Message = "File upload successfully",
                    Code = (int)result.HttpStatusCode,
                    NameImage = key,
                    Url = $"https://alkemy-ong.s3.amazonaws.com/{key}"
                };
                return response;
            }
            catch (AmazonS3Exception e)
            {
                return new AwsManagerResponse
                {
                   Message = "Error encountered when writing an objec",
                   Code = (int)e.StatusCode,
                   Errors =  e.Message
                };
            }
            catch (Exception e)
            {
                return new AwsManagerResponse
                {
                    Message = "Unknown encountered on server when writing an objec",
                    Code = 500,
                    Errors = e.Message
                };
            }
        }
        public async Task<AwsManagerResponse> AwsGetFileUrl(string key)
        {
            try
            {
                var request = new GetObjectRequest()
                {
                    BucketName = "alkemy-ong",
                    Key = key
                };

                using GetObjectResponse response = await _amazonS3.GetObjectAsync(request);

                var result = new AwsManagerResponse
                {
                    Message = "File encounterd successfully",
                    Code = 200,
                    NameImage = response.Key,
                    Url = $"https://alkemy-ong.s3.amazonaws.com/{response.Key}"
                };
                return result;
            }
            catch (AmazonS3Exception e)
            {
                return new AwsManagerResponse
                {
                    Message = "Error encountered when writing an objec",
                    Code = (int)e.StatusCode,
                    Errors = e.Message
                };
            }
            catch (Exception e)
            {
                return new AwsManagerResponse
                {
                    Message = "Unknown encountered on server when writing an objec",
                    Code = 500,
                    Errors = e.Message
                };
            }
        }
    }
}
