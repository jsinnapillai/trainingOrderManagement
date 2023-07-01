import type { CodegenConfig } from "@graphql-codegen/cli";

const config: CodegenConfig = {
  overwrite: true,
  schema: "http://localhost:5167/graphql/",
  documents: "./src/**/{*.gql,*.graphql}",
  generates: {
    "src/graphql/generated/schema.ts": {
      plugins: [
        "typescript",
        "typescript-operations",
        "typescript-react-apollo",
      ],
      // config: {
      //   withComponent: true,
      // },
    },
  },
};

export default config;
