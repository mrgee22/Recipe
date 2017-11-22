export class Recipe {
    recipeId: number;
    title: string;
    description: string;
    notes: string;
    createdBy: number;
    steps: Step[];
}

export class Step {
    description: string;
}