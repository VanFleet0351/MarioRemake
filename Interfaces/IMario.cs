using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZero.Pipes;
using SprintZero.Player;
using System;

namespace SprintZero.Interfaces
{
    public interface IMario
    {
        Vector2 Position { get; set; }
        IMarioState State { get; set; }
        ISprite sprite { get; set; }
        IMarioPhysicsObject physicsObject { get; set; }
        bool BigMario { get; set; }
        bool FireMario { get; set; }
        bool IceMario { get; set; }
        bool isFalling { get; set; }
        bool isJumping { get; set; }
        bool onPipe { get; set; }
        bool direction { get; set; }
        bool isCollidingWithFloor {get; set;}
        void WalkLeft();
        void WalkRight();
        void Sprint();
        void Jump();
        void Fall();
        void Land();
        void EnterPipe();
        void Crouch();
        void Climb();
        void Idle();
        void GetHit();
        void Big();
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate")]
        void Fire();
        void Ice();
        void UsePower();
        void UseStoredItem();
        void Star();
        void Die();
        void Draw(SpriteBatch spritebatch, Texture2D spritesheet, Color color);
        void Update();
        void Rewind();
        void Unwind();
        Boolean IsMarioDead();
        Rectangle RetrieveMarioRectangle();
        int storedItemInt { get; set; }
        bool hasStoredItem { get; set; }
    }
}
