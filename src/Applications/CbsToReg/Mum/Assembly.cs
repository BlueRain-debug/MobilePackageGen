﻿// Copyright (c) 2018, Gustave M. - gus33000.me - @gus33000
//
// Permission is hereby granted, free of charge, to any person obtaining a
// copy of this software and associated documentation files (the "Software"),
// to deal in the Software without restriction, including without limitation
// the rights to use, copy, modify, merge, publish, distribute, sublicense,
// and/or sell copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
// DEALINGS IN THE SOFTWARE.

using System.Xml.Serialization;

namespace CbsToReg.Mum
{
    [XmlRoot(ElementName = "assembly", Namespace = "urn:schemas-microsoft-com:asm.v3")]
    public class Assembly
    {
        public Assembly()
        {

        }

        [XmlElement(ElementName = "assemblyIdentity", Namespace = "urn:schemas-microsoft-com:asm.v3")]
        public AssemblyIdentity AssemblyIdentity
        {
            get; set;
        }

        [XmlArray(ElementName = "registryKeys", Namespace = "urn:schemas-microsoft-com:asm.v3")]
        [XmlArrayItem(ElementName = "registryKey")]
        public List<RegistryKey> RegistryKeys
        {
            get; set;
        }

        [XmlElement(ElementName = "package", Namespace = "urn:schemas-microsoft-com:asm.v3")]
        public Package Package
        {
            get; set;
        }

        [XmlAttribute(AttributeName = "xmlns")]
        public string Xmlns
        {
            get; set;
        }

        [XmlAttribute(AttributeName = "manifestVersion")]
        public string ManifestVersion
        {
            get; set;
        }

        [XmlAttribute(AttributeName = "displayName")]
        public string DisplayName
        {
            get; set;
        }

        [XmlAttribute(AttributeName = "company")]
        public string Company
        {
            get; set;
        }

        [XmlAttribute(AttributeName = "copyright")]
        public string Copyright
        {
            get; set;
        }

        //TODO: trustInfo
    }
}