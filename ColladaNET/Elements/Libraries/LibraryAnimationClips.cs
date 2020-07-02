using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ColladaNET.Elements
{
    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = Collada.XMLNAMESPACE)]
    [XmlRoot(Namespace = Collada.XMLNAMESPACE, IsNullable = false)]
    public partial class LibraryAnimationClips : LibraryBase<AnimationClip>
    {

        [XmlElement("animation_clip")]
        public List<AnimationClip> animation_clip
        {
            get { return this._items; }
            set { this._items = value; }
        }

        // constructors
        public LibraryAnimationClips() { }

        public LibraryAnimationClips(string id, string name)
            : base(id, name)
        { }

        public LibraryAnimationClips(string id, string name, AnimationClip[] animationClips)
            : base(id, name)
        { this._items.AddRange(animationClips); }

        public LibraryAnimationClips(AnimationClip[] animationClips)
        { this._items.AddRange(animationClips); }

    }

}
