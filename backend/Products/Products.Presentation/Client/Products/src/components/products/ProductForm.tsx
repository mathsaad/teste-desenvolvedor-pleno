import { NavLink, useNavigate, useParams } from "react-router-dom";
import {ChangeEvent, SyntheticEvent, useEffect, useState} from "react";
import { ProductDto } from "../../models/ProductDto";
import apiConnector from "../../api/apiConnector";
import {
    Button,
    DropdownProps,
    Form,
    FormField,
    FormGroup,
    FormInput,
    FormSelect,
    Message,
    Segment
} from "semantic-ui-react";

import { CategoriesDto } from "../../models/CategoriesDto.ts";
import { SuppliersDto } from "../../models/SuppliersDto.ts";
import {OptionDto} from "../../models/OptionDto.ts";
import {ProductDtoRequest} from "../../models/ProductDtoRequest.ts";

export default function ProductForm() {
    const { id } = useParams();
    const navigate = useNavigate();

    const [msg, setMsg] = useState('');
    
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
        suppliers: [],
    });

    const [_, setCategories] = useState<CategoriesDto[]>([]);
    const [suppliers, setSuppliers] = useState<SuppliersDto[]>([]);
    const [categoryOptions, setCategoryOptions] = useState<OptionDto[]>([]);
    const [selectedSuppliers, setSelectedSuppliers] = useState<number[]>([]);

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

                if (Array.isArray(product.suppliers)) {
                    const suppliersId: number[] = product.suppliers.map((supplier) => supplier.id);
                    setSelectedSuppliers(suppliersId);
                }
            });
        }
        getCategories();
        getSuppliers();
    }, [id]);

    function handleSubmit() {
        const productRequest : ProductDtoRequest = {
            id: product.id,
            name: product.name,
            description: product.description,
            price: product.price,
            quantity: product.quantity,
            categoryId: product.categoryId,
            supplierIds: selectedSuppliers,
        };
        
        if (!product.id) {
            apiConnector.createProduct(productRequest).then(() => navigate("/"));
        } else {
            apiConnector.editProduct(product.id, productRequest).then(() => navigate("/"));
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
            <Message color='yellow'>{msg}</Message>
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
                    type="number"
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
                                checked={selectedSuppliers.includes(supplier.id)}
                                onChange={() => handleSupplierChange(supplier.id)}
                            />
                        ))
                    ) : (
                        <span>Nenhum fornecedor</span>
                    )}
                </FormGroup>
                <Button floated="right" positive type="submit" onClick={
                    () => {
                        if (product.name === ''){
                            setMsg('Preencha o Nome!')    
                        }
                        if (product.description === ''){
                            setMsg('Preencha a Descrição!')    
                        }
                        if (product.price === 0){
                            setMsg('Preencha o Preço!')    
                        }
                        if (product.quantity === 0){
                            setMsg('Preencha a Quantidade!')    
                        }
                        if (product.categoryId === 0){
                            setMsg('Por Favor selecione a categoria!')
                        }
                        if (selectedSuppliers.length === 0){
                            setMsg('Por Favor selecione Fornecedores!')
                        }
                    }
                }>
                    Salvar
                </Button>
                <Button as={NavLink} to="/" floated="right" type="button" content="Cancel" />
            </Form>
        </Segment>
    );
}
