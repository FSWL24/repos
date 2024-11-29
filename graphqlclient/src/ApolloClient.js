import { ApolloClient, InMemoryCache, ApolloProvider } from '@apollo/client';

// Configura la URL de tu servidor GraphQL
const client = new ApolloClient({
  uri: 'https://localhost:7162/graphql/',
  cache: new InMemoryCache(), // Configuración del caché
});

const ApolloProviderComponent = ({ children }) => (
  <ApolloProvider client={client}>{children}</ApolloProvider>
);

export default ApolloProviderComponent;