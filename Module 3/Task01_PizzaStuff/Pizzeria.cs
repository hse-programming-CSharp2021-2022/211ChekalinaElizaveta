using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaStuff
{
    public class Pizzeria
    {
        // Склад для ингредиентов. Хранит количество каждого ингредиента.
        private Dictionary<Ingredients, int> storage = new Dictionary<Ingredients, int>();

        public Pizzeria()
        {
            foreach (var ingr in Enum.GetValues<Ingredients>())
            {
                storage[ingr] = 0;
            }
        }
        /// <summary>
        /// Привозит новые ингредиенты на склад.
        /// Увеличивает количество ингредиента ingredients на значение amount.
        /// </summary>
        /// <param name="ingredients"> Ингредиент, который будет привезен на склад. </param>
        /// <param name="amount"> Количество ингредиента. </param>
        public void DeliverIngredient(Ingredients ingredients, int amount)
        {
            this.storage[ingredients] += amount;
        }

        /// <summary>
        /// Возвращет информацию о количестве каждого ингредиента на складе.
        /// </summary>
        public (string name, int amount)[] GetStorage()
        {
            (string name, int amount)[] ans = new (string name, int amount)[Enum.GetNames(typeof(Ingredients)).Length];
            var names = Enum.GetNames<Ingredients>();
            for (int i = 0; i < names.Length; i++)
            {
                string name = names[i];
                Ingredients.TryParse(name, out Ingredients ingr);
                ans[i] = (names[i], storage[ingr]);
            }

            return ans;
        }

        /// <summary>
        /// Готовит пиццу по рецепту.
        /// </summary>
        /// <param name="recipe"> Рецепт пиццы. </param>
        /// <returns> Приготовленная пицца. </returns>
        /// <exception cref="PizzaException"> Если на складе не хватает ингредиентов, чтобы приготовить пиццу по рецепту.</exception>
        public Pizza MakePizza(PizzaRecipe recipe)
        {
            if (!this.HasIngredients(recipe))
            {
                throw new PizzaException("Not enough ingredients");
            }
            this.UseIngredients(recipe);
            return new Pizza(recipe);
        }

        /// <summary>
        /// Проверяет, есть ли на складе ингредиенты для рецепта.
        /// </summary>
        /// <param name="recipe"> Рецепт, наличие ингредиентов необходимо проверить. </param>
        /// <returns> true, если все ингредиенты есть на складе, false иначе. </returns>
        private bool HasIngredients(PizzaRecipe recipe)
        {
            foreach (var ingredient in Enum.GetValues<Ingredients>()) 
            {
                if (recipe.Ingredients.HasFlag(ingredient))
                {
                    if (this.storage[ingredient] < 1)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Удаляет со склада по одному ингредиенту из рецепта.
        /// </summary>
        /// <param name="recipe"></param>
        private void UseIngredients(PizzaRecipe recipe)
        {
            foreach (var ingredient in Enum.GetValues<Ingredients>())
            {
                if (recipe.Ingredients.HasFlag(ingredient))
                {
                    this.storage[ingredient] -= 1;
                }                
            }
        }

        public Pizza[] CompleteOrder(PizzaRecipe[] recipes)
        {
            Pizza[] pizzas = new Pizza[recipes.Length];
            for (int i = 0; i < recipes.Length; i++)
            {
                pizzas[i] =  MakePizza(recipes[i]);
            }

            return pizzas;
        }
    }
}
