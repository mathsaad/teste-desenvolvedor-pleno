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
        try{
            const response = await axios.get<GetProductResponse>(`${API_BASE_URL}/products`);
            return response.data.productsDto.map(product => ({
                ...product,
                createdDate: product.createdDate?.slice(0,10) ?? ""
            }));
        } catch (error) {
            console.log(error);
            throw error;
        }
    },

    getProductById: async (productId: string): Promise<ProductDto> => {
        try{
            const response = await axios.get<GetProductByIdResponse>(`${API_BASE_URL}/products/${productId}`);
            return response.data.productsDto;
        }catch (error) {
            console.log(error);
            throw error;
        }
    },
    
    createProduct: async (product: ProductDtoRequest): Promise<void> => {
        try {
            await axios.post(`${API_BASE_URL}/products`, product);
        }catch (error) {
            console.log(error);
            throw error;
        }
    },
    
    editProduct: async (productId: number, product: ProductDtoRequest): Promise<void> => {
        try {
            await axios.put(`${API_BASE_URL}/products/${productId}`, product);
        }catch (error) {
            console.log(error);
            throw error;
        }
    },
    
    deleteProduct: async (productId : number): Promise<void> => {
        try {
            await axios.delete<number>(`${API_BASE_URL}/products/${productId}`);
        } catch (error) {
            console.log(error);
            throw error;
        }
    },

    getCategoriesOptions: async (): Promise<CategoriesDto[]> => {
        try {
            const response = await axios.get<GetCategoryResponse>(`${API_BASE_URL}/category`);
            if (response.data && Array.isArray(response.data.categoriesDto)) {
                return response.data.categoriesDto.map((category) => ({
                    ...category,
                }));
            } else {
                throw new Error("Resposta inválida: 'categoryDto' não encontrado.");
            }
        } catch (error) {
            console.error("Erro ao buscar categorias:", error);
            throw error;
        }
    },

    getSuppliersOptions: async (): Promise<SuppliersDto[]> => {
        try {
            const response = await axios.get<GetSuppliersResponse>(`${API_BASE_URL}/supplier/`);
            if (response.data && Array.isArray(response.data.suppliersDto)) {
                return response.data.suppliersDto.map((suppliers) => ({
                    ...suppliers,
                }));
            } else {
                throw new Error("Resposta inválida: 'SuppliersDto' não encontrado.");
            }
        } catch (error) {
            console.error("Erro ao buscar Fornecedores:", error);
            throw error;
        }
    }
}
export default apiConnector;