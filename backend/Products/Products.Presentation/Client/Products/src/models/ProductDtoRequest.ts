export interface ProductDtoRequest  {
    id: number | undefined;
    name: string;
    description: string;
    price: number;
    quantity: number;
    categoryId: number | undefined;
    supplierIds: number[] | undefined[];
}