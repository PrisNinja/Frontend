import React from "react";
import "./ListItem.css";

const ListItem = (props) => {
	const unitAmountHandler = () => {
		if (props.amount < 1 && props.unit === "kg") {
			return props.amount * 1000 + "g";
		} else if (props.amount < 1 && props.unit === "l") {
			return props.amount * 1000 + "ml";
		} else {
			return props.amount + props.unit;
		}
	};

	return (
		<div className="list-item">
			<span className="list-item__left">{props.name}</span>
			<span className="list-item__right">
				<span className="unit-amount">{unitAmountHandler()}</span>
				<span className="item-buttons">
					<button onClick={() => props.onDecreaseAmount(props.id)}>-</button>
					<button onClick={() => props.onIncreaseAmount(props.id)}>+</button>
				</span>
				<button className="remove-button" onClick={() => props.onRemoveItem(props.id, props.name)}>Slet</button>
			</span>
		</div>
	);
};

export default ListItem;
