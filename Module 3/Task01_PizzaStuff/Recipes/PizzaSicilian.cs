using System;

namespace PizzaStuff.Recipes
{
    public sealed class PizzaSicilian : PizzaRecipe
    {
        private Ingredients _ingredients;

        public PizzaSicilian()
        {
            _ingredients = Ingredients.Dough | Ingredients.TomatoSauce | Ingredients.Anchovies | Ingredients.Parmesan;
        }
        public override string Name => "Sicilian";

        public override Ingredients Ingredients
        {
            get
            {
                return _ingredients;
            }
        }
    }
}
