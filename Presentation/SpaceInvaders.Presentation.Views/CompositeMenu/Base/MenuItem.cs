namespace SpaceInvaders.Presentation.Views.CompositeMenu.Base
{
    public abstract class MenuItem
    {
        public virtual void Add(MenuItem item)
        {
            throw new System.NotSupportedException();
        }

        public virtual void Remove(MenuItem item)
        {
            throw new System.NotSupportedException();
        }

        public virtual MenuItem GetChild(int index)
        {
            throw new System.NotSupportedException();
        }

        public abstract string Display();

        public abstract string GetName();
    }
}