using System;

namespace PizzaStuff.Recipes
{
    public sealed class PizzaPeperoni : PizzaRecipe
    {
        private Ingredients _ingredients;

        public PizzaPeperoni()
        {
            _ingredients = Ingredients.Dough | Ingredients.Peperoni | Ingredients.OliveOil | Ingredients.Herbs | Ingredients.Mozzarella;
        }
        public override string Name => "Peperoni";

        public override Ingredients Ingredients
        {
            get
            {
                return _ingredients;
            }
        }}
}
