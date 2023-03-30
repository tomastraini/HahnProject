# HahnProject

# About the project (business logic)
The project manages people (that can be either clients or suppliers, which is managed in the person types entity) and that people can then buy or sell us products.
These transactions are registered in father transactions (the one that has the most basic information) and each father transaction counts with many subtransaction attatched, and those subtransactions would impact the stock of the products, the person balance (it'd add up if it is a client because they owe us more, and the other way around in the case of suppliers).
It is a pretty simple but scalable project due to the architecture.

<br/>

# Technical details
The relation between entities is managed by triggers in the database por performance reasons. The architecture is DDD (Domain driven design) with an added service layer with dependency injection
