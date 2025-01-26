import {ProductDto} from "../../models/ProductDto.ts";
import {Button} from "semantic-ui-react";
import apiConnector from "../../api/apiConnector.ts";
import {NavLink} from "react-router-dom";

interface Props {
    product: ProductDto;
}

export default function ProductTableItem({product}: Props) {

    return (
        <>
            <tr className="center aligned">
                <td data-label="Id">{product.id}</td>
                <td data-label="Name">{product.name}</td>
                <td data-label="Description">{product.description}</td>
                <td data-label="Price">{product.price}</td>
                <td data-label="Quantity">{product.quantity}</td>
                <td data-label="Category">{product.categoryName}</td>
                <td data-label="Suppliers">{product.suppliers && product.suppliers.length > 0 ? (
                    product.suppliers.map((supplier) => (
                        <span key={supplier.id}>
                            {supplier.name}<br />
                        </span>
                    ))
                ) : (
                    <span>Nenhum fornecedor</span>
                )}</td>
                <td data-label="Actions">
                    <Button as={NavLink} to={`editProduct/${product.id}`} color="yellow" type="submit">Edit</Button>
                    <Button type="button" negative onClick={async () =>{
                        await apiConnector.deleteProduct(product.id!);
                        window.location.reload();
                    }}>Delete</Button>
                </td>
            </tr>
        </>
    )
}