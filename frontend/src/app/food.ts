export interface Food {
    id: number;
    name: string;
    foodGroupId: number;
    description: string | null;
}

export const foods: Food[] = [
    {
        id: 1,
        name: "Egg",
        foodGroupId: 0,
        description: "Good for health"
    },
    {
        id: 2,
        name: "Chicken",
        foodGroupId: 0,
        description: "Good for health"
    }, 
    {
        id: 3,
        name: "Onion",
        foodGroupId: 0,
        description: null
    }
]