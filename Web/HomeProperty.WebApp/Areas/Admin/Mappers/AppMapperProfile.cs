using AutoMapper;

namespace HomeProperty.WebApp.Areas.Admin.Mappers {
    public class AppMapperProfile : Profile {

        public override string ProfileName {
            get {
                return base.ProfileName + " Menu";
            }
        }

        protected override void Configure() {
            base.Configure();

            ////Menu and MenuViewModel
            //Mapper.CreateMap<Menu, MenuViewModel>();

            //Mapper.CreateMap<MenuViewModel, Menu>()
            //    .ForMember(dest => dest.MenuItems, mo => mo.Ignore());

            ////MenuItem and MenuItemViewModel
            //Mapper.CreateMap<MenuItem, MenuViewModel.MenuItemViewModel>();

            //Mapper.CreateMap<MenuViewModel.MenuItemViewModel, MenuItem>();

            ////MenuChildItem and MenuChildItemViewModel
            //Mapper.CreateMap<MenuChildItem, MenuViewModel.MenuChildItemViewModel>();

            //Mapper.CreateMap<MenuViewModel.MenuChildItemViewModel, MenuChildItem>();

        }
    }
}