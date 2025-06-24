using DinasPendidikan.Shared.Models.Users;

namespace DinasPendidikan.Shared.Models.Shared
{
    public abstract class BaseUserTrackedModel : BaseModel
    {
        public int CreatedById { get; set; }
        public User? CreatedBy { get; set; }
        public int? UpdatedById { get; set; }
        public User? UpdatedBy { get; set; }
    }
}
