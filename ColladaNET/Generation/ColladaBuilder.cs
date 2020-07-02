using ColladaNET.Elements;
using System;
using System.Collections.Generic;

namespace ColladaNET
{
    /// <summary>
    /// class used to create collada instances
    /// </summary>
    public partial class ColladaBuilder
    {

        #region Properties

        public float[] Positions { get; set; } = null;
        public float[] Normals { get; set; } = null;
        public float[] Texcoords { get; set; } = null;
        public float[] Vertexcolors { get; set; } = null;
        public int[] Triangles { get; set; } = null;

        #endregion


        /***
         * Create a storage variable to store unfinished COLLADA objects in
         * (this is necessary to pack multiple things into one one file without doing it at once)
         */

        private Collada _collada;
        public void Begin(string author = "", string authorTool = "ColladaNET", string copyright = "")
        {
            _collada = new Collada();
            _collada.asset = new Asset(new Asset.Contributor(author, authorTool, copyright + " " + DateTime.Now.Year, ""), DateTime.Now, DateTime.Now, new Asset.Unit(0.01f, "meter"), UpAxisType.Y_UP);
        }

        public Collada End()
        {
            _collada.libraries = new LibraryBase[] { LibraryImages, LibraryMaterials, LibraryEffects, LibraryGeometries, LibraryControllers, LibraryAnimations, LibraryVisualScenes };
            return _collada;
        }

        private void Clear()
        {
            LibraryGeometries = new LibraryGeometries();
            LibraryImages = new LibraryImages();
            LibraryMaterials = new LibraryMaterials();
            LibraryEffects = new LibraryEffects();
            LibraryVisualScenes = new LibraryVisualScenes();
            _collada.scene = null;
            _collada = null;
        }


        public LibraryGeometries LibraryGeometries { get; private set; } = new LibraryGeometries();
        public void AddGeometry(Geometry geometry)
        {
            List<Geometry> geometries = LibraryGeometries.geometry;
            if (geometries == null)
                geometries = new List<Geometry>();

            geometries.Add(geometry); // COLLADAGeometry.GenerateGeoTriangles(name, matName, positions, normals, texcoords, vertexColors, triangles);
            LibraryGeometries.geometry = geometries;
        }

        public LibraryImages LibraryImages { get; private set; } = new LibraryImages();
        public void AddImage(string id, string name, string imgSrc)
        {
            List<Image> images = LibraryImages.image;
            if (images == null)
                images = new List<Image>(); ;

            images.Add(new Image(id, name, imgSrc));
            LibraryImages.image = images;
        }

        public LibraryMaterials LibraryMaterials { get; private set; } = new LibraryMaterials();
        public void AddMaterial(string id, string name, string fxInstUrl)
        {
            List<Material> materials = LibraryMaterials.material;
            if (materials == null)
                materials = new List<Material>();

            materials.Add(new Material(id, name, new InstanceEffect(fxInstUrl)));
            LibraryMaterials.material = materials;
        }

        public LibraryEffects LibraryEffects { get; private set; } = new LibraryEffects();
        public void AddEffect(string id, string name, ColladaNET.FX.Profiles.Common shader)
        {
            List<Effect> effects = LibraryEffects.effect;
            if (effects == null)
                effects = new List<Effect>();

            effects.Add(new Effect(id, name, new ColladaNET.FX.Profiles.Common[] { shader }));
            LibraryEffects.effect = effects;
        }

        public LibraryControllers LibraryControllers { get; } = new LibraryControllers();
        public void AddController(Controller controller)
        {
            List<Controller> controllers = LibraryControllers.controller;
            if (controllers == null)
                controllers = new List<Controller>();

            controllers.Add(controller); // COLLADAGeometry.GenerateGeoTriangles(name, matName, positions, normals, texcoords, vertexColors, triangles);
            LibraryControllers.controller = controllers;
        }

        public LibraryAnimations LibraryAnimations { get; } = new LibraryAnimations();

        public void AddAnimation(Animation animation)
        {
            List<Animation> animations = LibraryAnimations.animation;
            if (animations == null)
                animations = new List<Animation>();

            animations.Add(animation);
            LibraryAnimations.animation = animations;
        }

        public LibraryVisualScenes LibraryVisualScenes { get; private set; } = new LibraryVisualScenes();
        public VisualScene AddVisualScene(string sceneName)
        {
            List<VisualScene> visualScenes = LibraryVisualScenes.visual_scene;
            if (visualScenes == null)
                visualScenes = new List<VisualScene>();

            VisualScene scene = new VisualScene(sceneName, sceneName);
            visualScenes.Add(scene);
            LibraryVisualScenes.visual_scene = visualScenes;
            return scene;
        }

        public void SetSceneInstanceVisualScene(string name, string sid, string url)
        {
            if (_collada.scene == null)
                _collada.scene = new Scene();
            _collada.scene.instance_visual_scene = new InstanceVisualScene(name, sid, url);
        }
    }
}
