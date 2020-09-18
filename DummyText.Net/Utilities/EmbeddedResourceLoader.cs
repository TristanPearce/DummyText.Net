using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace DummyText.Utils
{
    /// <summary>
    /// Utility for loading embedded resources.
    /// </summary>
    public class EmbeddedResourceLoader
    {
        private Assembly _assembly;
        private string _prefix;

        public Assembly Assembly => _assembly;
        public string Prefix => _prefix;

        /// <summary>
        /// Create an <see cref="EmbeddedResourceLoader"/> binded to the passed assembly.
        /// </summary>
        /// <param name="assembly">
        /// An assembly that this <see cref="EmbeddedResourceLoader"/> will attempt to load resources from.
        /// </param>
        /// <param name="prefix">
        /// A string prepended to all passed resource names.
        /// </param>
        public EmbeddedResourceLoader(Assembly assembly, string prefix)
        {
            _assembly = assembly;
            _prefix = prefix;
        }

        /// <summary>
        /// Return the names of all embedded resources.
        /// </summary>
        /// <returns></returns>
        public string[] GetResourceNames()
        {
            return _assembly.GetManifestResourceNames();
        }

        /// <summary>
        /// Get the names of all embedded resources that match the parameters.
        /// </summary>
        /// <param name="prefix"></param>
        /// <param name="contains"></param>
        /// <param name="suffix"></param>
        /// <returns></returns>
        public string[] GetResourceNames(string prefix = "", string contains = "", string suffix = "")
        {
            string[] all = _assembly.GetManifestResourceNames();
            return all.
                Where(x => x.StartsWith(prefix)). // Filter by prefix.
                Where(x => x.Contains(contains)). // Filter by contents.
                Where(x => x.EndsWith(suffix)).   // Filter by suffix.
                ToArray();                        // Convert to array.
        }

        /// <summary>
        /// Get a stream to an embedded resource.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Stream GetResource(string name)
        {
            string path = $"{_prefix}{name}";
            Stream s = _assembly.GetManifestResourceStream(path);

            if (s == null) 
                throw new EmbeddedResourceNotFound(path);
            else
                return s;
        }

        /// <summary>
        /// Gets an embedded resource as a string.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetResourceString(string name)
        {
            using Stream stream = _assembly.GetManifestResourceStream(_prefix + name);
            using TextReader streamReader = new StreamReader(stream);

            string result = streamReader.ReadToEnd();

            return result;
        }
    }

    /// <summary>
    /// Exception class representing when an embedded resource cannot be found.
    /// </summary>
    public class EmbeddedResourceNotFound : Exception
    {

        public EmbeddedResourceNotFound() : base()
        {

        }

        public EmbeddedResourceNotFound(string message) : base(message)
        {

        }

        public EmbeddedResourceNotFound(string message, Exception innerException) : base(message, innerException)
        {

        }

        protected EmbeddedResourceNotFound(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
