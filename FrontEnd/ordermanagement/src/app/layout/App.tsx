import { ApolloClient, ApolloProvider, InMemoryCache } from "@apollo/client";
import React from "react";
import CustomerDashBoard from "../../features/customers/customerDashBoard/CustomerDashBoard";

import "./styles.css";
const client = new ApolloClient({
  cache: new InMemoryCache({
    typePolicies: {},
  }),
  uri: "http://localhost:5167/graphql/",
});

function App() {
  return (
    <ApolloProvider client={client}>
      <CustomerDashBoard />
    </ApolloProvider>
  );
}

export default App;
