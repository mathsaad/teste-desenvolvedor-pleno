import {SuppliersDto} from "./SuppliersDto.ts";

export interface ProductDto {
    id: number | undefined;
    name: string;
    description: string;
    price: number;
    quantity: number;
    createdDate: string;
    categoryId: number | undefined;
    categoryName: string;
    categoryDescription: string;
    suppliers: SuppliersDto[]
}