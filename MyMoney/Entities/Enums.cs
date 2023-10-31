namespace MyMoney.Entities;

public enum TransactionType
{
	Expense,
	Income
}

public enum UserRole
{
	Reader,
	Editor,
	Moderator
}

public enum ExpenseCategory
{
	NoCategory = 0,
	Auto,
	Charity,
	BudgetAndTaxes,
	CargoTransport,
	Cash,
	MoneyTransfers,
	Investments,
	Other,
	OfficeSupplies,
	CafesAndRestaurants,
	Tickets,
	Cinema,
	Books,
	UtilitiesAndInternet,
	BeautyAndHealth,
	CourierServices,
	ClothesAndFootwear,
	LoanPayment,
	ClothingAndFootwear,
	HouseholdAppliances,
	Travel,
	MobileRecharge,
	GroceriesAndSupermarkets,
	AdvertisingServices,
	Repair,
	EntertainmentAndSports,
	Insurance,
	Taxi,
	Animals,
	FinesAndPenalties,
	Jewelry
}

public enum IncomeCategory
{
	NoCategory = 0,
	Salary,
	BusinessRevenue,
	InvestmentsReturns,
	RentIncome,
	Gifts,
	SaleOfGoods,
	FreelanceEarnings,
	Dividends,
	Interest,
	LoanReceived,
	TaxRefund,
	Pensions,
	Tips,
	Bonuses,
	DepositPayment,
	Other
}

public enum Frequency
{
	Daily,
	Weekly,
	BiWeekly,
	Monthly,
	BiMonthly,
	Quarterly,
	Annually,
}