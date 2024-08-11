import React from "react";
import ReactDOM from "react-dom/client";
import App from "./app/layout/App";
import { store, StoreContext } from "./app/stores/store";
import './utils/i18n'
//import './app/layout/styles.css'

ReactDOM.createRoot(document.getElementById("root")!).render(
  <React.StrictMode>
    <StoreContext.Provider value={store}>
      <App />
    </StoreContext.Provider>
  </React.StrictMode>
);
