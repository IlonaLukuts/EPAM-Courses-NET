namespace BussinessLayer.ObjectMapper
{
    using AutoMapper;

    using BussinessObjects;

    using DataLayer.Entities;

    public class ObjectMapper
    {
        IMapper mapper;
        public ObjectMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<FileEntity, FileWithSellings>();
                cfg.CreateMap<FileWithSellings, FileEntity>();

                cfg.CreateMap<ManagerEntity, Manager>();
                cfg.CreateMap<Manager, ManagerEntity>();

                cfg.CreateMap<SellingEntity, Selling>();
                cfg.CreateMap<Selling, SellingEntity>();
                
                cfg.CreateMap<UserEntity, User>();
                cfg.CreateMap<User, UserEntity>();
            });

            var mapper = config.CreateMapper();
        }

        public FileWithSellings ToBusinessObject(FileEntity dataObject)
        {
            return mapper.Map<FileEntity, FileWithSellings>(dataObject);
        }

        public Manager ToBusinessObject(ManagerEntity dataObject)
        {
            return mapper.Map<ManagerEntity, Manager>(dataObject);
        }

        public Selling ToBusinessObject(SellingEntity dataObject)
        {
            return mapper.Map<SellingEntity, Selling>(dataObject);
        }

        public User ToBusinessObject(UserEntity dataObject)
        {
            return mapper.Map<UserEntity, User>(dataObject);
        }

        public FileEntity ToDataObject(FileWithSellings businessObject)
        {
            return mapper.Map<FileWithSellings, FileEntity>(businessObject);
        }

        public ManagerEntity ToDataObject(Manager businessObject)
        {
            return mapper.Map<Manager, ManagerEntity>(businessObject);
        }

        public SellingEntity ToDataObject(Selling businessObject)
        {
            return mapper.Map<Selling, SellingEntity>(businessObject);
        }
        public UserEntity ToDataObject(User businessObject)
        {
            return mapper.Map<User, UserEntity>(businessObject);
        }

        public FileHashEntity ToHashDataObject(FileWithSellings bussinessObject, FileEntity dataObject)
        {
            var fileHashEntity = new FileHashEntity()
            {
                File = dataObject,
                Hash = bussinessObject.GetHashCode()
            };
            return fileHashEntity;
        }

        public SellingHashEntity ToHashDataObject(Selling bussinessObject, SellingEntity dataObject)
        {
            var sellingHashEntity = new SellingHashEntity()
            {
                Selling = dataObject,
                Hash = bussinessObject.GetHashCode()
            };
            return sellingHashEntity;
        }
    }
}
