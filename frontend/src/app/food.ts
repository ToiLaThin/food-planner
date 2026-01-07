export interface Food {
    id: number;
    name: string;
    foodGroupId: number;
    foodGroup: FoodGroup;
    description: string | null;
}

export interface FoodGroup {
    id: number;
    name: string;
    mainBenefit: string | null;
}

export const foods: Food[] = [
    {
        id: 1,
        name: "Egg",
        foodGroupId: 0,
        foodGroup: {
            id: 0,
            name: "Protein",
            mainBenefit: "Help you grow muscle"
        },
        description: "Good for health"
    },
    {
        id: 2,
        name: "Chicken",
        foodGroupId: 0,
        foodGroup: {
            id: 0,
            name: "Protein",
            mainBenefit: "Help you grow muscle"
        },
        description: "Good for health"
    }, 
    {
        id: 3,
        name: "Onion",
        foodGroupId: 0,
        foodGroup: {
            id: 0,
            name: "Protein",
            mainBenefit: "Help you grow muscle"
        },
        description: null
    }
]