import { NavLink, useNavigate, useParams } from "react-router-dom";
import {ChangeEvent, SyntheticEvent, useEffect, useState} from "react";
import { ProductDto } from "../../models/ProductDto";
import apiConnector from "../../api/apiConnector";
import {Button, DropdownProps, Form, FormField, FormGroup, FormInput, FormSelect, Segment} from "semantic-ui-react";
import { CategoriesDto } from "../../models/CategoriesDto.ts";
import { SuppliersDto } from "../../models/SuppliersDto.ts";
import {OptionDto} from "../../models/OptionDto.ts";
import {ProductDtoRequest} from "../../models/ProductDtoRequest.ts";

export default function ProductForm() {
    const { id } = useParams();
    const navigate = useNavigate();

    const [product, setProduct] = useState<ProductDto>({
        id: undefined,
        name: "",
        description: "",
        price: 0,
        quantity: 0,
        categoryId: 0,
        categoryName: "",
        categoryDescription: "",
        createdDate: "",
        suppliersDto: [],
    });

    const [_, setCategories] = useState<CategoriesDto[]>([]);
    const [suppliers, setSuppliers] = useState<SuppliersDto[]>([]);
    const [categoryOptions, setCategoryOptions] = useState<OptionDto[]>([]);
    const [selectedSuppliers, setSelectedSuppliers] = useState<number[]>([]); // Estado para fornecedores selecionados

    async function getCategories() {
        const response = await apiConnector.getCategoriesOptions();
        setCategories(response);

        const options: OptionDto[] = response.map((category: CategoriesDto) => ({
            key: category.id,
            value: category.id,
            text: category.name,
        }));
        setCategoryOptions(options);
    }

    async function getSuppliers() {
        const response = await apiConnector.getSuppliersOptions();
        setSuppliers(response);
    }

    useEffect(() => {
        if (id) {
            apiConnector.getProductById(id).then((product) => {
                setProduct(product);
            });
        }
        getCategories();
        getSuppliers();
    }, [id]);

    function handleSubmit() {
        console.log(selectedSuppliers)
        
        const productRequest : ProductDtoRequest = {
            name: product.name,
            description: product.description,
            price: product.price,
            quantity: product.quantity,
            categoryId: product.categoryId,
            supplierIds: selectedSuppliers,
        };
        
        console.log(productRequest)
        
        if (!product.id) {
            apiConnector.createProduct(productRequest).then(() => navigate("/"));
        } else {
            apiConnector.editProduct(productRequest).then(() => navigate("/"));
        }
    }

    function handleInputChange(event: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) {
        const { name, value } = event.target;
        setProduct({ ...product, [name]: value });
    }

    function handleCategoryChange( _: SyntheticEvent<HTMLElement, Event>, data: DropdownProps) {
        const categoryId = parseInt(data.value as string, 10);
        setProduct({ ...product, categoryId});
    }

    function handleSupplierChange(supplierId: number) {
        setSelectedSuppliers((prev) =>
            prev.includes(supplierId) ? prev.filter((id) => id !== supplierId) : [...prev, supplierId]
        );
    }

    return (
        <Segment clearing inverted>
            <Form onSubmit={handleSubmit} autoComplete="off" className="ui inverted form">
                <FormInput
                    placeholder="Nome"
                    name="name"
                    value={product.name}
                    onChange={handleInputChange}
                />
                <FormInput
                    placeholder="Descrição"
                    name="description"
                    value={product.description}
                    onChange={handleInputChange}
                />
                <FormInput
                    placeholder="Preço"
                    name="price"
                    value={product.price}
                    onChange={handleInputChange}
                />
                <FormInput
                    placeholder="Quantidade"
                    name="quantity"
                    value={product.quantity}
                    onChange={handleInputChange}
                />
                <FormSelect
                    placeholder="Categoria"
                    name="category"
                    options={categoryOptions}
                    value={product.categoryId}
                    onChange={handleCategoryChange}
                />
                <FormGroup grouped>
                    {suppliers.length > 0 ? (
                        suppliers.map((supplier) => (
                            <FormField
                                key={supplier.id}
                                label={supplier.name}
                                control="input"
                                type="checkbox"
                                checked={selectedSuppliers.includes(supplier.id)} // Marca o checkbox se o fornecedor estiver selecionado
                                onChange={() => handleSupplierChange(supplier.id)}
                            />
                        ))
                    ) : (
                        <span>Nenhum fornecedor</span>
                    )}
                </FormGroup>
                <Button floated="right" positive type="submit">
                    Salvar
                </Button>
                <Button as={NavLink} to="/" floated="right" type="button" content="Cancel" />
            </Form>
        </Segment>
    );
}
