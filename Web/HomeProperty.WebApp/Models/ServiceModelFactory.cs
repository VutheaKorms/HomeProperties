namespace HomeProperty.WebApp.Models {
    public class ServiceModelFactory {

        private static ICacheManager _cacheManager;
        public static ICacheManager CacheManager {
            get {
                if (_cacheManager == null)
                    _cacheManager = new CacheManager();
                return _cacheManager;
            }
        }

        public static IContactServiceModel _contactServiceModel;
        public static IContactServiceModel ContactServiceModel {
            get {
                if (_contactServiceModel == null)
                    _contactServiceModel = new ContactServiceModel();
                return _contactServiceModel;
            }
        }

    }
}