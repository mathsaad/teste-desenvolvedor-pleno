import ProductTable from "./components/products/ProductTable.tsx";
import {Container} from "semantic-ui-react";
import {Outlet, useLocation} from "react-router-dom";
import {useEffect} from "react";
import {setupErrorHandlingInterceptor} from "./interceptors/setupErrorHandlingInterceptor.ts";

function App() {
    const location = useLocation();

    useEffect(() => {
        setupErrorHandlingInterceptor();
    }, []);

  return (
    <>
        {location.pathname === "/" ? <ProductTable /> : (
            <Container className="container-style">
                <Outlet/>
            </Container>
        )}
    </>
  )
}

export default App
