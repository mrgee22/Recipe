import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'recipes',
    templateUrl: './recipes.component.html'
})

export class RecipeComponent {


    public recipes: Recipe[];

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        http.get(baseUrl + 'api/Recipe/GetRecipes').subscribe(result => {
            this.recipes = result.json() as Recipe[];
        }, error => console.error(error));
    }
}

interface Recipe {
    recipeId: number,
    title: string,
    description: string,
    notes: string,
    createdBy: number
    steps: Step[]
}

interface Step {
    description: string
}