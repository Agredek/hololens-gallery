using UnityEngine;

namespace Utils
{
    public static class TextureUtils
    {
        public static Sprite ToSprite(this Texture2D texture)
        {
            var rect = new Rect(0, 0, texture.width, texture.height);
            return Sprite.Create(texture, rect, new Vector2(0.5f, 0.5f));
        }
    }
}