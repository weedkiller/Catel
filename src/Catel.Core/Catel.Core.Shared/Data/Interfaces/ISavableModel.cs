﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISavableDataObjectBase.cs" company="Catel development team">
//   Copyright (c) 2008 - 2015 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Catel.Data
{
    using System.IO;
    using Runtime.Serialization;

#if NETFX_CORE
    using Windows.Storage.Streams;
#endif

    /// <summary>
    /// ISavableDataObjectBase that defines the additional methods to save a <see cref="IModel"/> object.
    /// </summary>
    public interface ISavableModel : IModel
    {
        #region Properties
        /// <summary>
        /// Gets or sets the <see cref="SerializationMode"/> of this object.
        /// </summary>
        /// <value>The serialization mode.</value>
        SerializationMode Mode { get; set; }
        #endregion

        #region Methods
#if NET || XAMARIN
        /// <summary>
        /// Saves the object to a file using the default formatting.
        /// </summary>
        /// <param name="fileName">Filename of the file that will contain the serialized data of this object.</param>
        /// <param name="configuration">The configuration.</param>
        void Save(string fileName, ISerializationConfiguration configuration = null);

        /// <summary>
        /// Saves the object to a file using a specific formatting.
        /// </summary>
        /// <param name="fileName">Filename of the file that will contain the serialized data of this object.</param>
        /// <param name="mode"><see cref="SerializationMode" /> to use.</param>
        /// <param name="configuration">The configuration.</param>
        void Save(string fileName, SerializationMode mode, ISerializationConfiguration configuration = null);

#elif NETFX_CORE
        /// <summary>
        /// Saves the object to an isolated storage file stream using the default formatting.
        /// </summary>
        /// <param name="fileStream">Stream that will contain the serialized data of this object.</param>
        void Save(IRandomAccessStream fileStream);
#elif PCL
        // Not supported in Portable Class Library
#else
        /// <summary>
        /// Saves the object to an isolated storage file stream using the default formatting.
        /// </summary>
        /// <param name="fileStream">Stream that will contain the serialized data of this object.</param>
        void Save(IsolatedStorageFileStream fileStream);
#endif

        /// <summary>
        /// Saves the object to a stream using the default formatting.
        /// </summary>
        /// <param name="stream">Stream that will contain the serialized data of this object.</param>
        /// <param name="configuration">The configuration.</param>
        void Save(Stream stream, ISerializationConfiguration configuration = null);

        /// <summary>
        /// Saves the object to a stream using a specific formatting.
        /// </summary>
        /// <param name="stream">Stream that will contain the serialized data of this object.</param>
        /// <param name="mode"><see cref="SerializationMode" /> to use.</param>
        /// <param name="configuration">The configuration.</param>
        void Save(Stream stream, SerializationMode mode, ISerializationConfiguration configuration = null);
        #endregion
    }
}