import React from "react";
import { useGetCusomersQuery } from "../../../graphql/generated/schema";

const CustomerDashBoard = () => {
  const { data: customersData, loading, error } = useGetCusomersQuery();

  if (loading) {
    return <div>Loading....</div>;
  }

  if (error || !customersData) {
    return <div>Errorloading....</div>;
  }

  return (
    <div>
      <ul>
        {customersData.customers?.map((customer) => {
          return (
            <li>
              {customer?.firstName}
              {customer?.lastName}
            </li>
          );
        })}
      </ul>
    </div>
  );
};

export default CustomerDashBoard;
