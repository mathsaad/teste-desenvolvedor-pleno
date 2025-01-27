import {ProductDto} from "../models/ProductDto.ts";
import axios from "axios";
import {GetProductResponse} from "../models/getProductsResponse.ts";
import {API_BASE_URL} from "../../config.ts";
import {GetProductByIdResponse} from "../models/getProductByIdResponse.ts";
import {GetCategoryResponse} from "../models/getCategoryResponse.ts";
import {CategoriesDto} from "../models/CategoriesDto.ts";
import {SuppliersDto} from "../models/SuppliersDto.ts";
import {GetSuppliersResponse} from "../models/getSuppliersResponse.ts";
import {ProductDtoRequest} from "../models/ProductDtoRequest.ts";

const apiConnector = {
    
    getProducts: async (): Promise<ProductDto[]> => {
        const response = await axios.get<GetProductResponse>(`${API_BASE_URL}/products`);
        return response.data.productsDto.map(product => ({
            ...product,
            createdDate: product.createdDate?.slice(0,10) ?? ""
        }));
    },

    getProductById: async (productId: string): Promise<ProductDto> => {
        const response = await axios.get<GetProductByIdResponse>(`${API_BASE_URL}/products/${productId}`);
        return response.data.productsDto;
    },
    
    createProduct: async (product: ProductDtoRequest): Promise<void> => {
        await axios.post(`${API_BASE_URL}/products`, product);
    },
    
    editProduct: async (productId: number, product: ProductDtoRequest): Promise<void> => {
        await axios.put(`${API_BASE_URL}/products/${productId}`, product);
    },
    
    deleteProduct: async (productId : number): Promise<void> => {
        await axios.delete<number>(`${API_BASE_URL}/products/${productId}`);
    },

    getCategoriesOptions: async (): Promise<CategoriesDto[]> => {
        const response = await axios.get<GetCategoryResponse>(`${API_BASE_URL}/category`);
        if (response.data && Array.isArray(response.data.categoriesDto)) {
            return response.data.categoriesDto.map((category) => ({
                ...category,
            }));
        } else {
            throw new Error("Resposta inválida: 'categoryDto' não encontrado.");
        }
    },

    getSuppliersOptions: async (): Promise<SuppliersDto[]> => {
        const response = await axios.get<GetSuppliersResponse>(`${API_BASE_URL}/supplier/`);
        if (response.data && Array.isArray(response.data.suppliersDto)) {
            return response.data.suppliersDto.map((suppliers) => ({
                ...suppliers,
            }));
        } else {
            throw new Error("Resposta inválida: 'SuppliersDto' não encontrado.");
        }
    }
}
export default apiConnector;