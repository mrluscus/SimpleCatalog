export class Product {
    id: string;
    name: string;
    price: number;
    quantity: number;
    productCategoryId: string;

    checked: boolean;
    highlighted?: boolean;
    hovered?: boolean;
}