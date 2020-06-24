using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApi.Domain.Entities.DataModel;
using TestApi.Domain.Interface;
using TestApi.Services.Dependency;
using TestApi.Services.Interfaces;

namespace TestApi.Services
{
    [TransientLifetime]
    public class TestService: ITestService
    {
        private readonly ITestRepository _testRepository;

        //public TestService()
        //{
            

        //}
        public TestService(ITestRepository testRepository)
        {
            _testRepository = testRepository;
           
        }

        public async Task<IEnumerable<CategoryDataModel>> GetCategoryInfo(string categoryId)
        {
            return await _testRepository.GetCategoryInfo(categoryId);
        }
        public async Task<IEnumerable<CategoryDataModel>> GetAllCategoryInfo()
        {
            return await _testRepository.GetAllCategoryInfo();
        }

        public async Task<IEnumerable<CategoryDataModel>> GetAllCategoryBindInfo()
        {
           
                var data = await _testRepository.GetAllCategoryBindInfo();

                var query = from c in data
                            group c by c.CategoryId into CategoryData
                            select new CategoryDataModel
                            {
                                CategoryId= CategoryData.Key,
                                CategoryName=(from c in CategoryData 
                                              select c.CategoryName
                                              ).FirstOrDefault(),
                                IsActive=(from c in CategoryData
                                          select c.IsActive
                                          ).FirstOrDefault(),
                                PostedOn= (from c in CategoryData
                                           select c.PostedOn
                                          ).FirstOrDefault(),
                                SubCategories= (from d in CategoryData
                                                group d by d.SubCategoryId into SubCategoryData
                                                select new SubCategoryDataModel
                                               {
                                                   SubCategoryId= SubCategoryData.Key,
                                                   SubCategory= (from d in SubCategoryData select d.SubCategory).FirstOrDefault(),
                                                    
                                                    SubSubCategories =( from sc in SubCategoryData
                                                                      select new SubSubCategoryDataModel
                                                                      {
                                                                          SubSubCategoryId=sc.subSubcategoryId,
                                                                          SubSubCategory=sc.SubSubCategory
                                                                      })
                                               })
                                

                            };


                return query;
            
        }
    }
}
