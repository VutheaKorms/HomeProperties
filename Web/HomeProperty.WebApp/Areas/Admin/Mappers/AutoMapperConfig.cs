using AutoMapper;

namespace HomeProperty.WebApp.Areas.Admin.Mappers {
    public class AutoMapperConfig {

        public static void Configure() {
            Mapper.Initialize(cfg => {
                cfg.AddProfile<AppMapperProfile>();
            });
        }

    }
}