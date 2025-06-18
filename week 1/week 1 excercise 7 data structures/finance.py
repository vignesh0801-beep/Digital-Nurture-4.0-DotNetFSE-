import requests

def predict_recursive(value, rate, years):
    if years == 0:
        return value
    return predict_recursive(value * (1 + rate), rate, years - 1)

def predict_memo(value, rate, years, memo):
    if years == 0:
        return value
    if years in memo:
        return memo[years]
    memo[years] = predict_memo(value * (1 + rate), rate, years - 1, memo)
    return memo[years]

def fetch_price_gecko():
    try:
        url = "https://api.coingecko.com/api/v3/simple/price"
        params = {'ids':'bitcoin', 'vs_currencies':'usd'}
        response = requests.get(url, params=params)
        return response.json()['bitcoin']['usd']
    except:
        return -1

def main():
    current_value = fetch_price_gecko()
    growth_rate = 0.07  # assume 7% annual growth
    if current_value == -1:
        print("Failed to fetch current value.")
        return
    years = int(input("Enter number of years to forecast: "))
    rec = predict_recursive(current_value, growth_rate, years)
    mem = predict_memo(current_value, growth_rate, years, {})
    print(f"Bitcoin now: ${current_value:.2f}")
    print(f"Recursive Forecast: ${rec:.2f}")
    print(f"Memoized Forecast: ${mem:.2f}")

if __name__ == "__main__":
    main()
