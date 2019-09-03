﻿using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.UI.BoundingBoxTypes;
using System.Collections.Generic;
using UnityEngine;

namespace Microsoft.MixedReality.Toolkit.UI
{
    class BoundingBoxHandleUtils
    {


        public static void SetHighlighted(Transform handleToHighlight, List<Transform> handles, Material highlightMaterial)
        {
            // turn off all handles that aren't the handle we want to highlight
            if (handles != null)
            {
                for (int i = 0; i < handles.Count; ++i)
                {
                    if (handles[i] != handleToHighlight)
                    {
                        handles[i].gameObject.SetActive(false);
                    }
                    else
                    {
                        BoundingBox.ApplyMaterialToAllRenderers(handles[i].gameObject, highlightMaterial);
                    }
                }
            }
        }

        public static void HandleIgnoreCollider(Collider handlesIgnoreCollider, List<Transform> handles)
        {
            if (handlesIgnoreCollider != null)
            {
                foreach (Transform handle in handles)
                {
                    Collider[] colliders = handle.gameObject.GetComponents<Collider>();
                    foreach (Collider collider in colliders)
                    {
                        UnityEngine.Physics.IgnoreCollision(collider, handlesIgnoreCollider);
                    }
                }
            }
        }

        public static Bounds GetMaxBounds(GameObject g)
        {
            var b = new Bounds();
            Mesh currentMesh;
            foreach (MeshFilter r in g.GetComponentsInChildren<MeshFilter>())
            {
                if ((currentMesh = r.sharedMesh) == null) { continue; }

                if (b.size == Vector3.zero)
                {
                    b = currentMesh.bounds;
                }
                else
                {
                    b.Encapsulate(currentMesh.bounds);
                }
            }
            return b;
        }



        /// <summary>
        /// Add all common components to a corner or rotate affordance
        /// </summary>
        /// <param name="afford"></param>
        /// <param name="bounds"></param>
        public static void AddComponentsToAffordance(GameObject afford, Bounds bounds, RotationHandlePrefabCollider colliderType, CursorContextInfo.CursorAction cursorType, Vector3 colliderPadding)
        {
            if (colliderType == RotationHandlePrefabCollider.Box)
            {
                BoxCollider collider = afford.AddComponent<BoxCollider>();
                collider.size = bounds.size;
                collider.center = bounds.center;
                collider.size += colliderPadding;
            }
            else
            {
                SphereCollider sphere = afford.AddComponent<SphereCollider>();
                sphere.center = bounds.center;
                sphere.radius = bounds.extents.x;
                sphere.radius += Mathf.Max(Mathf.Max(colliderPadding.x, colliderPadding.y), colliderPadding.z);
            }

            // In order for the affordance to be grabbed using near interaction we need
            // to add NearInteractionGrabbable;
            var g = afford.EnsureComponent<NearInteractionGrabbable>();
            g.ShowTetherWhenManipulating = drawTetherWhenManipulating;

            var contextInfo = afford.EnsureComponent<CursorContextInfo>();
            contextInfo.CurrentCursorAction = cursorType;
            contextInfo.ObjectCenter = rigRoot.transform;
        }

    }
}
