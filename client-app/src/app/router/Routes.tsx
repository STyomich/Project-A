import { createBrowserRouter, RouteObject } from "react-router-dom";
import App from "../layout/App";
import TopHundredDashboard from "../../features/anime/TopHundredDashboard";
import AnimeDetails from "../../features/anime/AnimeDetails";
import LoginForm from "../identity/LoginForm";

export const routes: RouteObject[] = [
  {
    path: "/",
    element: <App />,
    children: [
        {path: 'top-hundred-animes', element: <TopHundredDashboard />},
        {path: 'anime/:id', element: <AnimeDetails />},
        {path: 'login', element: <LoginForm />}
    ]
  },
];

export const router = createBrowserRouter(routes);
