// Define program variables var float entryPrice = 0.0
var string marketCondition = ""
var float gridStopLoss = 0.0
var float gridTakeProfit = 0.0
// Validate the market condition input void validateMarketCondition(string marketCond)
{if (marketCond != "up" & & marketCond != "down" & & marketCond != "sideways") {error("Invalid market condition")
                                                                                }   marketCondition = marketCond
 } // Get the entry price float getEntryPrice() {entryPrice = close[0]
                                                 return entryPrice
                                                 }
// Adjust grid levels based on market condition void adjustGridLevels()
{if (marketCondition == "up") {gridStopLoss = 0.03
                               gridTakeProfit = 0.06
                               }
 else if (marketCondition == "down") {gridStopLoss = 0.06
                                      gridTakeProfit = 0.03
                                      }
 else {gridStopLoss = 0.04
       gridTakeProfit = 0.04
       }
 }
// Adjust the stop loss and take profit levels void adjustStopProfit()
{strategy.stop = entryPrice * (1 - gridStopLoss)
 strategy.profit = entryPrice * (1 + gridTakeProfit)
 } // Place grid orders at valid price levels void generateGridOrders()
                                {// Add exception handling to prevent errors
                                   try {// Generate grid orders   } catch (Exception e)
                                    {error("Error generating grid orders: ", e)
                                     }}
                                // Calculate the risk/reward ratio float calculateRiskRewardRatio()
                                {return (strategy.profit - entryPrice) / (entryPrice - strategy.stop)
                                 }
                                // Log the execution of the program void logExecution() {
                                    // Log performance metrics try {
                                        // Logging code} catch(Exception e) {error("Error logging execution: ", e)
                                                                             }}
                                // Add an exit condition to the strategy void exitStrategy() {
                                    // Exit the strategy when the risk/reward ratio is no longer favorable if (calculateRiskRewardRatio() < 2) {strategy.close()
                                                                                                                                                }}
                                // Execute the program marketCondition = input(title="Market Condition",
                                                                               type=input.enum,
                                                                               options=[
                                                                                   "up", "down", "sideways"],
                                                                               default="sideways")
                                validateMarketCondition(marketCondition)
                                entryPrice = getEntryPrice()
                                adjustGridLevels()
                                adjustStopProfit()
                                generateGridOrders()
                                float riskRewardRatio = calculateRiskRewardRatio()
                                logExecution()
                                exitStrategy()
