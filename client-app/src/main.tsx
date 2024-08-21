import React from "react";
import ReactDOM from "react-dom/client";
import { store, StoreContext } from "./app/stores/store";
import "./utils/i18n";
import "./app/layout/styles.css";
import { RouterProvider } from "react-router-dom";
import { router } from "./app/router/Routes";

ReactDOM.createRoot(document.getElementById("root")!).render(
  <React.StrictMode>
    <StoreContext.Provider value={store}>
      <RouterProvider router={router} />
    </StoreContext.Provider>
  </React.StrictMode>
);
