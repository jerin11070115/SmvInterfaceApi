namespace TestApi.Domain.Entities.BodyModel.Admin
{
    public class ItemBodyModel
    {
        public string ItemName { get; set; } 
        public int CategoryId { get; set; }
        public int  SubCategoryId { get; set; }
        public int  SubSubCategoryId { get; set; }
        public string Description { get; set; }
        public int IsActive { get; set; }
    }
}
