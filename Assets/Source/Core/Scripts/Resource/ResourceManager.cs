namespace Core.Scripts.Resource {

    public abstract class ResourceManager : IResourceManager {

        /// <summary>
        /// Reference to resourceData script which contains resources.
        /// </summary>
        private ResourceData _resourceData;

        /// <summary>
        /// Constructor. Inits resourceData.
        /// </summary>
        public ResourceManager() {
            _resourceData = MakeResourceData();
        }

        /// <summary>
        /// Factory method. Must be implemented in child class.
        /// </summary>
        protected abstract ResourceData MakeResourceData();

        /// <summary>
        /// ResourceData getter.
        /// </summary>
        public ResourceData resourceData {
            get {
                return _resourceData;
            }
        }

    }

}