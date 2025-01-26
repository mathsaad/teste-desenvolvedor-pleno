import ProductTable from "./components/products/ProductTable.tsx";
import {Container} from "semantic-ui-react";
import {Outlet, useLocation} from "react-router-dom";

function App() {
    const location = useLocation();

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
