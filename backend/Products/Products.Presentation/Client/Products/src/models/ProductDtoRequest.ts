export interface ProductDtoRequest  {
    name: string;
    description: string;
    price: number;
    quantity: number;
    categoryId: number | undefined;
    supplierIds: number[] | undefined[];
}