namespace OOP_Game_Engine.Component
{
    using System;

    class GameObjectVisual : GameObject
    {
        private OOP_Game_Engine.Rend.Visual visual;

        public override void Render()
        {
            visual.Render();
        }
    }
}
