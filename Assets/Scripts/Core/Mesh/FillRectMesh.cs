using UnityEngine;

namespace FairyGUI
{
    public class FillRectMesh : FillMesh
    {
        public Vector4 border;

        public FillRectMesh()
        {
        }

        public override void OnPopulateMesh(VertexBuffer vb)
        {
            FillRect(vb, vb.contentRect, border);
        }

        public override void OnPopulateMesh(VertexBuffer vb, NTexture texture)
        {
            FillRect(vb, vb.contentRect, border);
        }
        
        static void FillRect(VertexBuffer vb, Rect vertRect, Vector4 border)
        {
            vertRect.x += vertRect.width * border.x;
            vertRect.y += vertRect.height * border.y;
            vertRect.width *= 1 - border.x - border.z;
            vertRect.height *= 1 - border.y - border.w;
            vb.AddQuad(vertRect);
            vb.AddTriangles();
        }
    }
}