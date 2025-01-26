import {useEffect, useState} from "react";
import {ProductDto} from "../../models/ProductDto.ts";
import apiConnector from "../../api/apiConnector.ts";
import {Button, Container} from "semantic-ui-react";
import ProductTableItem from "./ProductTableItem.tsx";
import {NavLink} from "react-router-dom";

export default function ProductTable() {

    const [products, setProducts] = useState<ProductDto[]>([]);
    useEffect(() => {
        const fetchData = async () => {
            const fetchProducts = await apiConnector.getProducts();
            setProducts(fetchProducts);
        }
        fetchData();
    }, []);
    
    return (
        <>
            <Container className="container-style">
                   <table className="ui inverted table">
                       <thead style={{textAlign: 'center'}}>
                       <tr>
                           <th>Id</th>
                           <th>Nome</th>    
                           <th>Descrição</th>    
                           <th>Preço</th>    
                           <th>Quantidade</th>    
                           <th>Categoria</th>    
                           <th>Fornecedores</th>    
                           <th>Ações</th>
                       </tr>
                       </thead>
                       <tbody>
                       {products.length !== 0 && (
                           products.map((product, index) => (
                               <ProductTableItem key={index} product={product}/>
                           ))
                       )}
                       </tbody>
                   </table>
                <Button as={NavLink} to="createProduct" floated="right" type="button" content="Criar Produto" positive/>
            </Container>
        </>
    )
}