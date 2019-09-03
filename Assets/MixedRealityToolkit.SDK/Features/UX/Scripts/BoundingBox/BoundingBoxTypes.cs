﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.MixedReality.Toolkit.UI.BoundingBoxTypes
{
    /// <summary>
    /// Enum which describes how an object's boundingbox is to be flattened.
    /// </summary>
    public enum FlattenModeType
    {
        DoNotFlatten = 0,
        /// <summary>
        /// Flatten the X axis
        /// </summary>
        FlattenX,
        /// <summary>
        /// Flatten the Y axis
        /// </summary>
        FlattenY,
        /// <summary>
        /// Flatten the Z axis
        /// </summary>
        FlattenZ,
        /// <summary>
        /// Flatten the smallest relative axis if it falls below threshold
        /// </summary>
        FlattenAuto,
    }

    /// <summary>
    /// Enum which describes whether a boundingbox handle which has been grabbed, is 
    /// a Rotation Handle (sphere) or a Scale Handle( cube)
    /// </summary>
    public enum HandleType
    {
        None = 0,
        Rotation,
        Scale
    }

    /// <summary>
    /// This enum describes which primitive type the wireframe portion of the boundingbox
    /// consists of. 
    /// </summary>
    /// <remarks>
    /// Wireframe refers to the thin linkage between the handles. When the handles are invisible
    /// the wireframe looks like an outline box around an object.
    /// </remarks> 
    public enum WireframeType
    {
        Cubic = 0,
        Cylindrical
    }


    /// <summary>
    /// This enum defines what volume type the bound calculation depends on and its priority
    /// for it.
    /// </summary>
    public enum BoundsCalculationMethod
    {
        /// <summary>
        /// Used Renderers for the bounds calculation and Colliders as a fallback
        /// </summary>
        RendererOverCollider = 0,
        /// <summary>
        /// Used Colliders for the bounds calculation and Renderers as a fallback
        /// </summary>
        ColliderOverRenderer,
        /// <summary>
        /// Omits Renderers and uses Colliders for the bounds calculation exclusively
        /// </summary>
        ColliderOnly,
        /// <summary>
        /// Omits Colliders and uses Renderers for the bounds calculation exclusively
        /// </summary>
        RendererOnly,
    }

    /// <summary>
    /// This enum defines how the BoundingBox gets activated
    /// </summary>
    public enum BoundingBoxActivationType
    {
        ActivateOnStart = 0,
        ActivateByProximity,
        ActivateByPointer,
        ActivateByProximityAndPointer,
        ActivateManually
    }

    /// <summary>
    /// This enum defines the type of collider in use when a rotation handle prefab is provided.
    /// </summary>
    public enum RotationHandlePrefabCollider
    {
        Sphere,
        Box
    }


   

    /// <summary>
    /// Internal state tracking for proximity of a handle
    /// </summary>
    public enum HandleProximityState
    {
        FullsizeNoProximity = 0,
        MediumProximity,
        CloseProximity
    }



    /// <summary>
    /// This enum defines which of the axes a given rotation handle revolves about.
    /// </summary>
    public enum CardinalAxisType
    {
        X = 0,
        Y,
        Z
    }
}
