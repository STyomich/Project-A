import { observer } from "mobx-react-lite";
import { useStore } from "../stores/store";
import { ErrorMessage, Field, Form, Formik } from "formik";
import * as Yup from "yup";
import { useNavigate } from "react-router-dom";
import { Box } from "@mui/material";

export default observer(function LoginForm() {
  const { userStore } = useStore();
  const navigate = useNavigate();

  // Validation schema using Yup
  const validationSchema = Yup.object({
    email: Yup.string()
      .email("Invalid email address")
      .required("Email is required"),
    password: Yup.string().required("Password is required"),
  });

  return (
    <Box  sx={{
        display: "flex",
        justifyContent: "center",
        alignItems: "top",
        minHeight: "100vh",
        marginTop: "100px",
      }} >
      <Formik
        initialValues={{ email: "", password: "" }}
        validationSchema={validationSchema}
        onSubmit={(values, { setSubmitting }) => {
          userStore
            .login(values)
            .then(() => {
              navigate("/"); // Redirect on successful login
            })
            .finally(() => {
              setSubmitting(false); // reset the submitting state after login
            });
        }}
      >
        {({ isSubmitting }) => (
          <Form>
            <div>
              <label htmlFor="email">Email</label>
              <Field name="email" type="email" />
              <ErrorMessage name="email" component="div" />
            </div>

            <div>
              <label htmlFor="password">Password</label>
              <Field name="password" type="password" />
              <ErrorMessage name="password" component="div" />
            </div>

            <button type="submit" disabled={isSubmitting}>
              {isSubmitting ? "Logging in..." : "Login"}
            </button>
          </Form>
        )}
      </Formik>
    </Box>
  );
});
