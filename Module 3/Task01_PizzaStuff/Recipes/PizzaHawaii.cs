using System;

namespace PizzaStuff.Recipes
{
    public sealed class PizzaHawaii : PizzaRecipe
    {
        private Ingredients _ingredients;

        public PizzaHawaii()
        {
            _ingredients = Ingredients.Dough | Ingredients.Ham | Ingredients.Pineapple | Ingredients.Mozzarella;
        }
        public override string Name => "Hawaii";

        public override Ingredients Ingredients
        {
            get
            {
                return _ingredients;
            }
        } }
}
