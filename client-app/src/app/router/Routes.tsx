import { createBrowserRouter, RouteObject } from "react-router-dom";
import App from "../layout/App";
import TopHundredDashboard from "../../features/anime/TopHundredDashboard";

export const routes: RouteObject[] = [
  {
    path: "/",
    element: <App />,
    children: [
        {path: 'top-hundred-animes', element: <TopHundredDashboard />},
        {path: 'anime/:id',}
    ]
  },
];

export const router = createBrowserRouter(routes);
