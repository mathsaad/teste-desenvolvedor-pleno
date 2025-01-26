import {createBrowserRouter, RouteObject} from "react-router-dom";
import App from "../App.tsx";
import ProductForm from "../components/products/ProductForm.tsx";
import ProductTable from "../components/products/ProductTable.tsx";

export const routes: RouteObject[] = [
    {
        path: '/',
        element: <App/>,
        children: [
            { path: 'createProduct', element: <ProductForm key='create'/> },
            { path: 'editProduct/:id', element: <ProductForm key='edit'/> },
            { path: '*', element: <ProductTable/> }
        ]
    }
]

export const router = createBrowserRouter(routes)